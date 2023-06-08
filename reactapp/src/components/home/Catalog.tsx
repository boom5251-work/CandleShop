import React, { Component } from 'react';
import ProductView from './ProductView.tsx';
import '../../resources/styles/Home.css';

export default class Catalog extends Component<any, any> {
    static displayName: string = Catalog.name;


    constructor(props) {
        super(props);
        this.state = { products: [] };
    }


    render(): React.ReactNode {
        return (
            <section className="catalog-section">
                <div className="content-container">
                    <div className="products-container">
                        {this.state.products.map(product => this.createProductView(product))}
                    </div>
                    <p className="products-description">
                        Мы&nbsp;приглашаем вас&nbsp;посетить наш магазин свечей и&nbsp;выбрать свечи, которые
                        добавят тепла и&nbsp;уюта в&nbsp;вашу жизнь. Наши&nbsp;продукты прекрасно дополнят
                        интерьер вашей квартиры или&nbsp;помогут создать приятную атмосферу в&nbsp;ресторане,
                        спа-салоне или&nbsp;гостиничном номере. Мы&nbsp;гарантируем вам&nbsp;высокое качество наших
                        продуктов и&nbsp;индивидуальный подход к&nbsp;каждому клиенту.
                    </p>
                </div>
            </section>
        );
    }


    componentDidMount(): void {
        this.getProducts()
            .then(data => this.setState({ products: data }));
    }


    // Асинхронно выполняет GET-запрос на сервер.<br />
    // Получает товары с 0 по 6 (не включительно).
    async getProducts(): Promise<any> {
        const response: Response = await fetch('api/products?from=0&to=6');
        return response.json();
    }


    // Создает представление товара.
    createProductView(product): ProductView {
        return <ProductView
            key={product.id}
            name={product.name}
            description={product.description}
            price={product.price}
            imageSource={`/api/files/images?product-id=${product.id}`}
        />
    }
}
