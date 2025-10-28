import { Component } from '@angular/core';
import { IEmpresa } from '../../Models/empresa.model';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa-service';

@Component({
  selector: 'app-excluir-empresa',
  standalone: false,
  templateUrl: './excluir-empresa.html',
  styleUrl: './excluir-empresa.css',
})
export class ExcluirEmpresa {
  empresa! : IEmpresa;

  constructor(private service : EmpresaService, private router : Router, private route : ActivatedRoute){}

  excluirEmpresa(){
    const id = this.route.snapshot.paramMap.get('id');

    if (id){
      this.service.excluir(id).subscribe(() => {
        this.router.navigate(['/listarEmpresas']);
      })
    }
  }

  cancelar(){
    this.router.navigate(['/listarEmpresas']);
  }
}
