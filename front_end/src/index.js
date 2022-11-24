import React from "react";
import ReactDOM from "react-dom/client";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import { ProviderData } from "./configs/contextData";
import "./index.scss";
import Categories from "./layouts/categories/Categories";
import Cart from "./pages/Cart";
import Detail from "./pages/Detail";
import Home from "./pages/Home";
import Main from "./pages/Main";
import reportWebVitals from "./reportWebVitals";

const router = createBrowserRouter([
    {
        element: <Main />,
        children: [
            {
                path: "/",
                element: <Home />,
            },
            {
                path: "/products/categories/:category",
                element: <Categories />,
            },
            {
                path: "/:category/:categoryId",
                element: <Detail />,
            },
            {
                path: "/cart/:categoryId",
                element: <Cart />,
            },
        ],
    },
    {
        path: "/login",
        element: <div>login</div>,
    },
]);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <ProviderData>
        <RouterProvider router={router}></RouterProvider>,
    </ProviderData>,
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
