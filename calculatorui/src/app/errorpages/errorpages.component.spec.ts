import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ErrorPagesComponent } from './errorpages.component';

xdescribe('ErrorpagesComponent', () => {
  let component: ErrorPagesComponent;
  let fixture: ComponentFixture<ErrorPagesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ErrorPagesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ErrorPagesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
