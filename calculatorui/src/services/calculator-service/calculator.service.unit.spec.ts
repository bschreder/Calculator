import { TestBed, inject } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient } from '@angular/common/http';
import { from } from 'rxjs';

import { DataService } from 'src/services/data-service/data.service';
import { CalculatorService } from './calculator.service';
import { CalculateApiResponse } from '../../common/model/calculateApiResponse';



describe('CalculatorService', () => {
    let service: CalculatorService;
    const inputValue = '3+4=';
    const resultValue: CalculateApiResponse = { result: inputValue + '7', error: [ 'tip top' ]};

    beforeEach(async () => {
        TestBed.configureTestingModule({
            imports: [ HttpClientTestingModule ],
            // declarations: [  ],
            providers: [ DataService, CalculatorService ]
          })
          .compileComponents();
    });

    beforeEach(() => {
        service = TestBed.get(CalculatorService);
    });

    it ('should return calculated value', () => {
        const dataService = TestBed.get(DataService);
        spyOn(dataService, 'create').and.returnValue(from ([ resultValue ]));

        service.calculate(inputValue).subscribe((data) => {
            expect(data.result).toBe(resultValue.result);
            expect(data.error).toBe(resultValue.error);
        });
    });
});