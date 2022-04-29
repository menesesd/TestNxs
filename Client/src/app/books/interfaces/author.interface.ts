import { Book } from "./book.interface";

export interface Author {
    id?:          number;
    fullName:    string;
    dateOfBirth: Date;
    cityOrigin:  string;
    email:       string;
    books:       Book[];
}
