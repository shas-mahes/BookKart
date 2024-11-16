import { BaseModel } from "./base";
import { Books } from "./boots";
import { User } from "./user";

export interface Cart extends BaseModel {
    Quantity: number;
    BookId: number;
    Books: Books;
    UserId: number;
    Users: User;
}