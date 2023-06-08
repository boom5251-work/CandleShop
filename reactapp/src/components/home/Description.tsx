import React, {Component} from 'react';
import candlesAdditionPreview from '../../resources/images/candles-additional-preview.png';
import leaves1 from '../../resources/images/leaves-1.png';
import leaves2 from '../../resources/images/leaves-2.png';
import '../../resources/styles/Home.css';

export default class Description extends Component<any, any> {
    static displayName: string = Description.name;


    render(): React.ReactNode {
        return (
            <section className="description-section">
                <img src={candlesAdditionPreview} className="candles-additional-preview" alt="Свечи" />
                <div className="content-container">
                    <img src={leaves1} className="leaves-1" alt="Листья" />
                    <img src={leaves2} className="leaves-2" alt="Листья" />

                    <p className="first-text text">
                        Зажигая свечу, мы&nbsp;создаем атмосферу уюта и&nbsp;тепла в&nbsp;нашей жизни. Свечи
                        могут быть прекрасным подарком для&nbsp;нас&nbsp;самих или&nbsp;для&nbsp;наших близких.
                        И&nbsp;если вы&nbsp;ищете магазин, где&nbsp;можно купить красивые и&nbsp;качественные
                        свечи, то&nbsp;мы&nbsp;рады предложить вам&nbsp;нашу&nbsp;продукцию.
                    </p>
                    <p className="last-text text">
                        Наши&nbsp;свечи изготавливаются из&nbsp;натуральных материалов, безопасных для&nbsp;здоровья
                        и&nbsp;окружающей среды. Кроме того, у&nbsp;нас&nbsp;широкий ассортимент свечей различных
                        форм, размеров и&nbsp;ароматов. Вы&nbsp;можете выбрать свечи с&nbsp;нежным ароматом лаванды
                        или&nbsp;свежевымытыми бергамотом, а&nbsp;может быть, вам&nbsp;понравятся свечи с&nbsp;ярким
                        и&nbsp;насыщенным ароматом ванили или&nbsp;корицы.
                    </p>
                </div>
            </section>
        );
    }
}