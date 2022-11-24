import { ShoppingCart } from "@mui/icons-material";
import AcUnitIcon from "@mui/icons-material/AcUnit";
import GrainIcon from "@mui/icons-material/Grain";
import NavigateNextIcon from "@mui/icons-material/NavigateNext";
import {
    Breadcrumbs,
    Button,
    Link,
    Rating,
    Stack,
    Typography,
} from "@mui/material";
import React, { useEffect, useState } from "react";
import { NavLink, useParams } from "react-router-dom";
import useSWR from "swr";
import { colors } from "../assets/data/colors";
import { images } from "../assets/data/image";
import { sizes } from "../assets/data/sizes";
import { fakestoreApi, fetcher } from "../configs/fetchApi";

const Detail = () => {
    const { categoryId } = useParams();
    const { data } = useSWR(fakestoreApi.getDetails(categoryId), fetcher);
    const [details, setDetails] = useState(null);
    const [detailsImage, setDetailsImage] = useState();

    useEffect(() => {
        if (!data) return;
        if (data) {
            setDetails(data);
            setDetailsImage(data.image);
        }
    }, [data, details]);

    if (!details) return;

    return (
        <div className=" bg-[#F5F5F5] py-20">
            <div className="container">
                <nav>
                    <ul className="flex items-center justify-start gap-5">
                        <li>
                            <NavLink
                                to="/"
                                className={({ isActive }) =>
                                    isActive
                                        ? ""
                                        : "text-blue-500 font-semibold"
                                }
                            >
                                Home{" "}
                            </NavLink>
                            <NavigateNextIcon />
                        </li>
                        <li>
                            <NavLink
                                to={`/products/categories/${details.category}`}
                                className={({ isActive }) =>
                                    isActive
                                        ? ""
                                        : "text-blue-500 font-semibold"
                                }
                            >
                                {details.category}{" "}
                            </NavLink>
                            <NavigateNextIcon />
                        </li>
                        <li>{details.title}</li>
                    </ul>
                </nav>
                <div className="flex bg-white">
                    <div className="p-5">
                        <div>
                            <img
                                srcSet={detailsImage}
                                alt={details.title}
                                key={details.image}
                                className="h-[30rem]"
                            />
                        </div>
                        <div className="flex gap-5 my-3">
                            {images.slice(0, 4).map((image, index) => (
                                <div
                                    className="w-20 h-20 shrink-0 "
                                    key={image}
                                    onClick={() => setDetailsImage(image)}
                                >
                                    <img
                                        src={image}
                                        alt={image}
                                        className="object-cover w-full cursor-pointer"
                                    />
                                </div>
                            ))}
                        </div>
                    </div>
                    <div className="p-5">
                        <div className="flex flex-col gap-y-10">
                            <Typography variant="h5">
                                {details.title}
                            </Typography>
                            <div role="presentation">
                                <Breadcrumbs aria-label="breadcrumb">
                                    <Link
                                        underline="hover"
                                        sx={{
                                            display: "flex",
                                            alignItems: "center",
                                            gap: "5px",
                                        }}
                                        color="inherit"
                                    >
                                        <Typography component="legend">
                                            {details.rating.rate}
                                        </Typography>
                                        <Rating value={5} disabled />
                                    </Link>
                                    <Link
                                        underline="none"
                                        sx={{
                                            display: "flex",
                                            alignItems: "center",
                                            gap: "5px",
                                        }}
                                        color="inherit"
                                    >
                                        <Typography
                                            component="span"
                                            className="border-b-2 border-black"
                                        >
                                            {details.rating.count}
                                        </Typography>
                                        <div className="capitalize">
                                            đánh giá
                                        </div>
                                    </Link>
                                    <Typography
                                        sx={{
                                            display: "flex",
                                            alignItems: "center",
                                        }}
                                        color="text.primary"
                                    >
                                        <GrainIcon
                                            sx={{ mr: 0.5 }}
                                            fontSize="inherit"
                                        />
                                        Breadcrumb
                                    </Typography>
                                </Breadcrumbs>
                            </div>
                            <div className="p-5 bg-[#f5f5f5] ">
                                <Typography variant="h5" textAlign={"center"}>
                                    ₫{details.price}
                                </Typography>
                            </div>

                            <div className="flex items-center space-x-8">
                                <Typography>Màu Sắc</Typography>
                                <div className="flex gap-5">
                                    {colors.map((color) => (
                                        <span
                                            key={color.display}
                                            className="px-5 py-3 capitalize border whitespace-nowrap"
                                        >
                                            {color.display}
                                        </span>
                                    ))}
                                </div>
                            </div>
                            <div className="flex items-center space-x-16">
                                <Typography>Size</Typography>
                                <div className="flex gap-5">
                                    {sizes.map((size, index) => (
                                        <span
                                            key={index}
                                            className="px-5 py-3 border whitespace-nowrap"
                                        >
                                            {size.display}
                                        </span>
                                    ))}
                                </div>
                            </div>
                            <div className="flex items-center space-x-8">
                                <Typography>Số lượng</Typography>
                                <div className="flex">
                                    <span className="px-5 py-3 border cursor-pointer">
                                        -
                                    </span>
                                    <span className="px-5 py-3 border">1</span>
                                    <span className="px-5 py-3 border cursor-pointer">
                                        +
                                    </span>
                                </div>
                            </div>
                            <Stack direction="row" spacing={2}>
                                <NavLink to={`/cart/${categoryId}`}>
                                    <Button
                                        variant="outlined"
                                        startIcon={<ShoppingCart />}
                                    >
                                        Thêm vào giỏ hàng
                                    </Button>
                                </NavLink>
                                <Button variant="contained">Mua ngay</Button>
                            </Stack>
                        </div>
                    </div>
                </div>
                <div className="p-10 mt-10 bg-white">
                    <Typography variant="h4" className="p-5 bg-[#F5F5F5]">
                        Mô tả sản phẩm
                    </Typography>
                    <div className="p-5">
                        <Typography>
                            <AcUnitIcon />
                            {details.title}
                        </Typography>
                        <Typography component="div" className="p-5">
                            {details.description}
                        </Typography>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default Detail;
