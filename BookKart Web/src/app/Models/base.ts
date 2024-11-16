export interface BaseModel {
    Id: number;
    CreatedBy: string;
    ModifiedBy?: string;
    CreatedDate: Date;
    ModifiedDate?: Date;
}