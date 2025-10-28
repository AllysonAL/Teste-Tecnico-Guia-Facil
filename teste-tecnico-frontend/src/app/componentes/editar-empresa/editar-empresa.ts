import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmpresaService } from '../../services/empresa-service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-editar-empresa',
  standalone: false,
  templateUrl: './editar-empresa.html',
  styleUrl: './editar-empresa.css',
})
export class EditarEmpresa implements OnInit {
  formulario! : FormGroup;

  constructor(private service : EmpresaService, private router : Router, private route : ActivatedRoute, private formBuilder : FormBuilder){}

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      id: [null],
      nome: ['', Validators.compose([Validators.required, Validators.pattern(/(.|\s)*\S(.|\s)*/)])],
      cnpj: ['', Validators.compose([Validators.required, Validators.pattern(/^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$/)])],
      email: ['', Validators.compose([Validators.required, Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/)])],
      telefone: ['', Validators.compose([Validators.required, Validators.pattern(/^\(\d{2}\) \d{4,5}-\d{4}$/)])],
      endereco: ['', Validators.compose([Validators.required, Validators.pattern(/^[A-Za-zÀ-ú0-9\s\.,-]+, \d+$/)])]
    });

    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
        this.service.buscarPorId(id).subscribe((empresa) => {
        this.formulario.patchValue(empresa);
      });
    }
  }

  editarEmpresa(){
    this.service.editar(this.formulario.value).subscribe(() =>{
      this.router.navigate(['/listarEmpresas']);
    })
  }

  cancelar(){
    this.router.navigate(['/listarEmpresas']);
  }

  habilitarBotao() : string {
    return (this.formulario.valid) ? 'botao' : 'botao__desabilitado';
  }
}
