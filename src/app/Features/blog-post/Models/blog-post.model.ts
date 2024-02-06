import { Category } from "../../Category/Models/Category.model";


export interface BlogPost {
    id: string;
    title: string;
    shortDescription: string;
    content: string;
    featuredImageUrl: string;
    urlHandle: string;
    author: string;
    publishedDate: Date;
    isvisible: Boolean;
    categories: Category[];
}