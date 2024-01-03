import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroProductorComponent } from './registro-productor.component';

describe('RegistroProductorComponent', () => {
  let component: RegistroProductorComponent;
  let fixture: ComponentFixture<RegistroProductorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RegistroProductorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RegistroProductorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
