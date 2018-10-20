import { Injectable } from '@angular/core';
import { DataService } from '../data-service/data.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CalculateApiResponse } from 'src/common/model/calculateApiResponse';


@Injectable()
export class CalculatorService {
    private url = 'http://localhost/CalculatorApi/api/Math';
    private dataService: DataService;

    constructor(httpClient: HttpClient) {
        this.dataService = new DataService(httpClient);
    }

    calculate(value: string): Observable<CalculateApiResponse> {
        const inputObj = { 'input' : value };
        return this.dataService.create(this.url, inputObj);
    }
}
