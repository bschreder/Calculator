import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { HttpClientModule } from '@angular/common/http';
import { from } from 'rxjs';

import { CalculatorService } from 'src/services/calculator-service/calculator.service';
import { CalculateApiResponse } from 'src/common/model/calculateApiResponse';
import { CalculatorComponent } from './calculator.component';
import { componentFactoryName } from '@angular/compiler';


describe('CalculatorComponent', () => {
    let fixture: ComponentFixture<CalculatorComponent>;
    let component: CalculatorComponent;

    beforeEach(async(() => {
      TestBed.configureTestingModule({
        imports: [ FormsModule, ReactiveFormsModule, HttpClientTestingModule ],
        declarations: [ CalculatorComponent ],
        providers: [ CalculatorService ]
      }).compileComponents();
    }));

    beforeEach(() => {
        fixture = TestBed.createComponent(CalculatorComponent);
        component = fixture.componentInstance;
      });

    it('should display 1', (() => {
        component.topRow = '';
        const button = fixture.debugElement.query(By.css('#one'));

        button.triggerEventHandler('click', null);

        expect(component.topRow).toBe('1');
      }));

    it('should display 2', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#two'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('2');
    }));

    it('should display 3', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#three'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('3');
    }));

    it('should display 4', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#four'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('4');
    }));

    it('should display 5', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#five'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('5');
    }));

    it('should display 6', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#six'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('6');
    }));

    it('should display 7', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#seven'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('7');
    }));

    it('should display 8', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#eight'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('8');
    }));

    it('should display 9', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#nine'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('9');
    }));


    it('should display ^', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#power'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('^');
    }));

    it('should display +', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#addition'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('+');
    }));

    it('should display -', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#subtraction'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('-');
    }));

    it('should display *', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#multiplication'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('*');
    }));

    it('should display /', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#division'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('/');
    }));

    it('should display %', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#modulus'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('%');
    }));



    it('should display (', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#left-parenthesis'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('(');
    }));

    it('should display )', (() => {
      component.topRow = '';
      const button = fixture.debugElement.query(By.css('#right-parenthesis'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe(')');
    }));

    it('should clear last character when backspace', (() => {
      const input = '691';
      component.topRow = input;
      component.bottomRow = input;
      const button = fixture.debugElement.query(By.css('#back-space'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe(input.substring(0, input.length - 1));
      expect(component.bottomRow). toBe(input);
    }));

    it('should clear top display only', (() => {
      const input = '691';
      component.topRow = input;
      component.bottomRow = input;
      const button = fixture.debugElement.query(By.css('#clear-entry'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('');
      expect(component.bottomRow). toBe(input);
    }));

    it('should clear top and bottom display', (() => {
      const input = '691';
      component.topRow = input;
      component.bottomRow = input;
      const button = fixture.debugElement.query(By.css('#clear'));

      button.triggerEventHandler('click', null);

      expect(component.topRow).toBe('');
      expect(component.bottomRow).toBe('');
    }));
});