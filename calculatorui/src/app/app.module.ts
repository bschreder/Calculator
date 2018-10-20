import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, RouterOutlet } from '@angular/router';

import { AppErrorHandler } from '../common/error-handler/app-error-handler';
import { CalculatorComponent } from './calculator/calculator.component';
import { NotFoundComponent } from './notfound/notfound.component';
import { ErrorPagesComponent } from './errorpages/errorpages.component';
import { NavbarComponent } from './navbar/navbar.component';


@NgModule({
  declarations: [
    AppComponent,
    NotFoundComponent,
    ErrorPagesComponent,
    NavbarComponent,
    CalculatorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: CalculatorComponent },
      { path: 'error', component: ErrorPagesComponent },
      { path: '**', component: NotFoundComponent }
    ])
  ],
  providers: [
    { provide: ErrorHandler, useClass: AppErrorHandler}
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
