import { Author } from "./author.interface";
import { Editorial } from "./editorial.interface";

export interface Book {
    id?:          number;
    tittle:      string;
    year:        number;
    gender:      string;
    numberPages: number;
    editorialId: number;
    authorId:    number;
    author?:     Author;
    editorial?:  Editorial;
}