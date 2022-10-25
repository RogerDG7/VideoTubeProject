import { PaginationResponse } from "./PaginationResponse";
import { Video } from "./Video";

export interface PaginationVideo {
    videoModels: Array<Video>;
    paginationResponse: PaginationResponse;
}