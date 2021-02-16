/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { MathematicComponent } from './mathematic.component';

describe('MathematicComponent', () => {
  let component: MathematicComponent;
  let fixture: ComponentFixture<MathematicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MathematicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MathematicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
