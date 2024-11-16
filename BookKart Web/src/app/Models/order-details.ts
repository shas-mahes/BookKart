import { BaseModel } from "./base";
import { Books } from "./boots";
import { User } from "./user";

export interface OrderDetails extends BaseModel {
    ShippingId: string;
    ShippingAddress: string;
    Landmark: string;
    City: string;
    State: string;
    Pincode: number;
    BookId: number;
    Books: Books;
    UserId: number;
    Users: User
}