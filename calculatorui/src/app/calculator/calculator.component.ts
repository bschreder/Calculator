import { Component, OnInit, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
import { CalculatorService } from '../../services/calculator-service/calculator.service';
import { CalculateApiResponse } from 'src/common/model/calculateApiResponse';


@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.css']
})

@Injectable()
export class CalculatorComponent implements OnInit {
  error: string[];
  topRow: string;
  bottomRow: string;


  form = new FormGroup({
    topRow: new FormControl(''),
    bottomRow: new FormControl(''),
  });


  constructor(private apiService: CalculatorService) { }

  ngOnInit() {
    this.error = null;
    this.topRow = '';
    this.bottomRow = '';
  }

  onOperandClick(c: string) {
    this.topRow = this.topRow + c;
  }

  onOperatorClick(c: string) {
    this.topRow = this.topRow + c;
  }


  onActionClick(c: string) {
    switch (c) {
      case '=':
        this.topRow = this.topRow + c;
        // this.bottomRow = `${this.topRow}   `;
        this.calculate(this.topRow);
        break;
      case 'backspace':
        this.topRow = this.topRow.slice(0, -1);
        break;
      case 'clearentry':
        this.topRow = '';
        break;
      case 'clear':
        this.topRow = '';
        this.bottomRow = '';
        break;
      default:
        this.error.push('Invalid operator');
        break;
    }
  }

  calculate(value: string) {
    console.log('calculate');
    console.log(value);

    this.apiService.calculate(value)
      .subscribe((data: CalculateApiResponse) => {
        console.log('subscribe return');
        console.log(data);
          this.bottomRow = `${value}${data.result['Output']}`;
          this.error = data.error;
          this.topRow = '';
      });
  }

  get hasErrors() {
    if (this.error) { return true; }
    return false;
    }
}
