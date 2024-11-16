import { BaseModel } from "./base";
import { UserRole } from "./user-role";

export interface User extends BaseModel {
    FirstName: string;
    LastName: string;
    EmailId: string;
    Password: string;
    Contact: string;
    RoleId: number;
    Role: UserRole
}