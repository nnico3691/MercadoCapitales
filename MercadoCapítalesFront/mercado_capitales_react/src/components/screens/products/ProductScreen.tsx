import { FC } from "react";

type Props = {
    productName: string,
    productDescription: string | undefined
}

const ProductScreen: FC<Props> = ({ productName, productDescription }) => {
    return <>
        <h1>{productName}</h1>
        {productDescription && <h2>{productDescription}</h2>}
    </>
}

export default ProductScreen;