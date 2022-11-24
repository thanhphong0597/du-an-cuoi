import React from "react";

const ProductItem = ({ item }) => {
    return (
        <div>
            <img src={item.image} alt="" />
        </div>
    );
};

export default ProductItem;
