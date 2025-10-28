import { Component, OnInit } from '@angular/core';
import { IEmpresa } from '../../Models/empresa.model';
import { EmpresaService } from '../../services/empresa-service';

@Component({
  selector: 'app-listar-empresas',
  standalone: false,
  templateUrl: './listar-empresas.html',
  styleUrl: './listar-empresas.css',
})
export class ListarEmpresas implements OnInit {
  constructor(private service: EmpresaService) {}

  filtro : string = '';
  listaEmpresas : IEmpresa[] = [];
  titulo : string = 'Empresas cadastradas';

  ngOnInit(): void {
    this.pesquisarEmpresas();
  }

  pesquisarEmpresas() {
    this.service.listar(this.filtro).subscribe((empresas) => {
      this.listaEmpresas = empresas;
    });
  }
}
