import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaCadastrarComponent } from './sala-cadastrar.component';

describe('SalaCadastrarComponent', () => {
  let component: SalaCadastrarComponent;
  let fixture: ComponentFixture<SalaCadastrarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalaCadastrarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaCadastrarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
