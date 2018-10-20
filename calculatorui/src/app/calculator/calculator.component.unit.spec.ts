import { async, ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClientModule } from '@angular/common/http';
import { from } from 'rxjs';

import { CalculatorComponent } from './calculator.component';
import { CalculatorService } from 'src/services/calculator-service/calculator.service';
import { CalculateApiResponse } from '../../common/model/calculateApiResponse';


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
    fixture = TestBed.createComponent(CalculatorComponent);
    component = fixture.componentInstance;
  });

  it('should display entered operand', () => {
    component.topRow = '';
    const input = '21';

    component.onOperandClick(input);

    expect(component.topRow).toContain(input);
  });

  it('should display entered operator', () => {
    component.topRow = '';
    const input = '+';

    component.onOperatorClick(input);

    expect(component.topRow).toContain(input);
  });

  it('should clear last character when backspace', () => {
    component.topRow = '4+5/3';

    component.onActionClick('backspace');

    const testValue = component.topRow.substring(0, component.topRow.length - 1);
    expect(component.topRow).toContain(testValue);
  });

  it('should clear top display only', () => {
    const input = '6+3+4';
    component.topRow = input;
    component.bottomRow = input;

    component.onActionClick('clearentry');

    expect(component.topRow).toBe('');
    expect(component.bottomRow).toBe(input);
  });

  it('should clear top and bottom display', () => {
    const input = '6+3+4';
    component.topRow = input;
    component.bottomRow = input;

    component.onActionClick('clear');

    expect(component.topRow).toBe('');
    expect(component.bottomRow).toBe('');
  });

  xit('should call = to calculate value', async(() => {
    const input = '6+2*4/3';
    component.topRow = input;
    const resultValue: number = Math.floor(6 + 2 * 4 / 3);
    const resultObj = { 'Output' : resultValue };

    const response: CalculateApiResponse = { result: JSON.stringify(resultObj), error: [ 'tip top' ]};
    // console.log(response);

    const calculatorService = TestBed.get(CalculatorService);
    spyOn(calculatorService, 'calculate').and.returnValue(from ([ response ]));

    component.onActionClick('=');
    // fixture.detectChanges();

    console.log(component);

    expect(component.topRow).toBe('');
    expect(component.bottomRow).toBe(input + '=' + response.result['Output']);
    expect(component.error).toBe(response.error);
    expect(component.hasErrors).toBeTruthy();
  }));
});
