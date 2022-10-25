import { PaginationVideo } from "./PaginationVideo";

export interface ApiResponseVideoPag {
    status: string;
    message: Array<string>;
    objectResponse: PaginationVideo;
}