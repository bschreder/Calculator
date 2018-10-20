import { TestBed, getTestBed, inject } from '@angular/core/testing';
import { HttpErrorResponse } from '@angular/common/http';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

import { DataService } from './data.service';
import { ApiResponse } from 'src/common/model/apiResponse';


describe('DataService', () => {
    const fakeUrl = '/foo/bar/';

    beforeEach(async () => {
        TestBed.configureTestingModule({
            imports: [ HttpClientTestingModule ],
            providers: [ DataService ]
          })
          .compileComponents();
    });

    afterEach(inject([HttpTestingController], (httpMock: HttpTestingController) => {
        httpMock.verify();
    }));


    it('should issue get request', inject([HttpTestingController], (httpMock: HttpTestingController) => {
        const httpValue: ApiResponse = { result: 'myResult', error: ['myError'] };
        const dataService = TestBed.get(DataService);

        dataService.getAll(fakeUrl).subscribe((data: ApiResponse) => {
            expect(data.result).toBe(httpValue.result);
            expect(data.error).toBe(httpValue.error);
          }
        );

        const req = httpMock.expectOne(dataService);
        expect(req.request.method).toEqual('GET');
        expect(req.request.url).toEqual(fakeUrl);

        req.flush(httpValue);
      }));

      it('should fail on get request', inject([HttpTestingController], (httpMock: HttpTestingController) => {
        const httpValue: ApiResponse = { result: 'myResult', error: ['myError'] };
        const dataService = getTestBed().get(DataService);

        dataService.getAll(fakeUrl).subscribe(
            response => fail('should fail with 500 status'),
            (error: HttpErrorResponse) => {
                expect(error).toBeTruthy();
                // expect(error.status).toEqual(500);
            }
        );

        const req = httpMock.expectOne(dataService);
        expect(req.request.method).toEqual('GET');
        expect(req.request.url).toEqual(fakeUrl);

        //  should return AppError
        req.flush({ errorMessage: 'Uh oh!' }, { status: 500, statusText: 'Server Error' });
      }));


      it('should issue create request', inject([HttpTestingController], (httpMock: HttpTestingController) => {
        const reqValue = 'temp req';
        const httpValue: ApiResponse = { result: 'myResult', error: ['myError'] };
        const dataService = getTestBed().get(DataService);

        dataService.create(fakeUrl, reqValue).subscribe((data: ApiResponse) => {
            expect(data.result).toBe(httpValue.result);
            expect(data.error).toBe(httpValue.error);
          }
        );

        const req = httpMock.expectOne(dataService);
        expect(req.request.method).toEqual('POST');
        expect(req.request.url).toEqual(fakeUrl);

        req.flush(httpValue);
      }));
});