export interface UpdateBlogPost {
    title: string;
    shortDescription: string;
    content: string;
    featuredImageUrl: string;
    urlHandle: string;
    author: string;
    publishedDate: Date;
    isvisible: Boolean;
    categories: string[];
}