import { ApiResponse } from './apiResponse';

export class CalculateApiResponse extends ApiResponse {
    result: string;
    error: string[];
}