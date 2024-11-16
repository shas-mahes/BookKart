import { BaseModel } from "./base";
import { Category } from "./category";

export interface Books extends BaseModel {
    Title: string;
    Author: string;
    CategoryId: number;
    Category: Category;
    Price: number;
    CoverFileName: string;
    Count: number;
    IsAvailable: boolean;
}