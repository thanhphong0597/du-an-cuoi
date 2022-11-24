import Grid from "@mui/material/Unstable_Grid2";
import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import useSWR from "swr";
import { fakestoreApi, fetcher } from "../../configs/fetchApi";
import BannerCategory from "../banner/BannerCategory";
import Category from "./Category";

const Categories = () => {
    const { category } = useParams();
    const { data } = useSWR(fakestoreApi.getProductList(), fetcher);
    const [categories, setCategories] = useState(null);

    useEffect(() => {
        if (!data) return;
        if (category) {
            const filter = data.filter((item) => item.category === category);
            setCategories(filter);
        }
    }, [category, data]);

    if (!categories) return;

    return (
        <div className="flex py-16">
            <BannerCategory />
            <Grid
                container
                spacing={{ xs: 2, md: 3 }}
                columns={{ xs: 4, sm: 8, md: 12 }}
                sx={{ padding: "20px" }}
            >
                {categories.length > 0 &&
                    categories.map((category) => (
                        <Grid xs={2} sm={4} md={4} key={category.id}>
                            <Category category={category} />
                        </Grid>
                    ))}
            </Grid>
        </div>
    );
};

export default Categories;
