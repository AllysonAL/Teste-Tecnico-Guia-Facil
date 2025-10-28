import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExcluirEmpresa } from './excluir-empresa';

describe('ExcluirEmpresa', () => {
  let component: ExcluirEmpresa;
  let fixture: ComponentFixture<ExcluirEmpresa>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExcluirEmpresa]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExcluirEmpresa);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
