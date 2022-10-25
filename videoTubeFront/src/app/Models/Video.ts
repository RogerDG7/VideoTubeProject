import { Users } from "./Users";

export interface Video{
    id: string;
    title: string;
    description: string;
    likes: number;
    dislikes: number;
    thumbnailUrl: string;
    uloapDate: string;
    userId: string;
    url: string | '';
    users: Users;
}