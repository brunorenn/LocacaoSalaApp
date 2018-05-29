import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SalaListarComponent } from './sala-listar.component';

describe('SalaListarComponent', () => {
  let component: SalaListarComponent;
  let fixture: ComponentFixture<SalaListarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SalaListarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SalaListarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
