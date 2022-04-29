import { Book } from "./book.interface";

export interface Editorial {
    id?:                    number;
    name:                  string;
    addressCorrespondence: string;
    phone:                 number;
    email:                 string;
    maximumBook:           number;
    books:                 Book[];
}
