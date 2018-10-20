import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClientModule } from '@angular/common/http';
import { from } from 'rxjs';

import { CalculatorService } from 'src/services/calculator-service/calculator.service';
import { CalculateApiResponse } from 'src/common/model/calculateApiResponse';
import { CalculatorComponent } from './calculator.component';


describe('CalculatorComponent', () => {
    let fixture: ComponentFixture<CalculatorComponent>;
    let component: CalculatorComponent;

    beforeEach(async(() => {
      TestBed.configureTestingModule({
        imports: [ FormsModule, ReactiveFormsModule, HttpClientTestingModule, HttpClientModule ],
        declarations: [ CalculatorComponent ],
        providers: [ CalculatorService ]
      }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.get(CalculatorComponent);
        component = fixture.componentInstance;
      });

    xit('should call to calculate value', async(() => {
        const input = '6+2*4/3';
        component.topRow = input;
        const resultValue: CalculateApiResponse = { result: input + '=4', error: [ 'tip top' ]};

        const calculatorService = TestBed.get(CalculatorService);
        spyOn(calculatorService, 'calculate').and.returnValue(from ([ {'Output': resultValue } ]));

        component.onActionClick('=');
        fixture.detectChanges();

        console.log(component);

        expect(component.topRow).toBe('');
        expect(component.bottomRow).toBe(resultValue.result);
        expect(component.error).toBe(resultValue.error);
        expect(component.hasErrors).toBeTruthy();
      }));
});