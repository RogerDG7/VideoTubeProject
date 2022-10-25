import { Users } from "./Users";

export interface CommentModel {
    videoId: string;
    userId: string;
    text: string;
    publishDate: string;
    users: Users
}