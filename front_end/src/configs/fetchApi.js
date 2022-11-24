export const fetcher = (...args) => fetch(...args).then((res) => res.json());
export const fakestoreApi = {
    getProductList: () => `https://fakestoreapi.com/products`,
    getCategory: () => `https://fakestoreapi.com/products/categories`,
    getCategoryType: (category) =>
        `https://fakestoreapi.com/products/categories/${category}`,
    getDetails: (productId) => `https://fakestoreapi.com/products/${productId}`,
};
