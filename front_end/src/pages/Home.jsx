import { Typography } from "@mui/material";
import React from "react";
import { useData } from "../configs/contextData";
import BannerHome from "../layouts/banner/BannerHome";
import ProductItem from "../layouts/product/ProductItem";

const Home = () => {
    const { products } = useData();
    return (
        <div className="p-20">
            <BannerHome />
            <div>
                <div className="bg-[#F8F8F8] text-center">
                    <Typography variant="h3" component="div">
                        Bạn đang xem tất cả sản phẩm
                    </Typography>
                    <span>{products.length} sản phẩm</span>
                </div>
                <div>
                    {products.map((product) => (
                        <ProductItem key={product.id} item={product} />
                    ))}
                </div>
            </div>
        </div>
    );
};

export default Home;
