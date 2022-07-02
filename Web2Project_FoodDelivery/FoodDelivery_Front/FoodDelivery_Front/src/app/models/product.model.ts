export class ProductDto{
    id:number = 0;
    name:string = '';
    price:number = 0.0;
    ingredients:string = '';
    amount:number = 0;
    email:string = '';
}

export class OrderProductDto{
    id:number = 0;
    productId:number = 0;
    orderId:number = 0;
    currentPrice:number = 0.0;
    amount:number = 0;
    orderDate:Date = new Date();
}

export class UserProductDto{
    email:string = '';
    orderId:number = 0;
}