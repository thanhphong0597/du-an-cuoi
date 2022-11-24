import useSWR from "swr";
import { fakestoreApi, fetcher } from "./fetchApi";

const { createContext, useState, useContext, useEffect } = require("react");

const ContextData = createContext();

const ProviderData = ({ children, ...props }) => {
    const [carts, setCarts] = useState([]);
    const [products, setProducts] = useState([]);
    const { data } = useSWR(fakestoreApi.getProductList(), fetcher);

    useEffect(() => {
        if (!data) return;
        if (data) {
            setProducts(data);
        }
        if (!products) return;
    }, [data, products]);

    const values = { carts, setCarts, products };
    return (
        <ContextData.Provider value={values} {...props}>
            {children}
        </ContextData.Provider>
    );
};

const useData = () => {
    const context = useContext(ContextData);
    return context;
};

export { ProviderData, useData };
