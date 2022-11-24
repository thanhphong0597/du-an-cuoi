import React from "react";
import { useParams } from "react-router-dom";

const Cart = () => {
    const { categoryId } = useParams();
    // var api = `sadfkjnskfnsdk/${categoryId}`
    // fetch(api)

    return <div>cart</div>;
};

export default Cart;

