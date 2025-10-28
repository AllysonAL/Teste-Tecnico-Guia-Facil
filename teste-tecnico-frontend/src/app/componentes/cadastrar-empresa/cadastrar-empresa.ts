import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { EmpresaService } from '../../services/empresa-service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastrar-empresa',
  standalone: false,
  templateUrl: './cadastrar-empresa.html',
  styleUrl: './cadastrar-empresa.css',
})
export class CadastrarEmpresa implements OnInit {
  formulario! : FormGroup;

  constructor(private service : EmpresaService, private router : Router, private formBuilder : FormBuilder){}

  ngOnInit(): void {
    this.formulario = this.formBuilder.group({
      nome: ['', Validators.compose([Validators.required, Validators.pattern(/(.|\s)*\S(.|\s)*/)])],
      cnpj: ['', Validators.compose([Validators.required, Validators.pattern(/^\d{2}\.\d{3}\.\d{3}\/\d{4}-\d{2}$/)])],
      email: ['', Validators.compose([Validators.required, Validators.pattern(/^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/)])],
      telefone: ['', Validators.compose([Validators.required, Validators.pattern(/^\(\d{2}\) \d{4,5}-\d{4}$/)])],
      endereco: ['', Validators.compose([Validators.required, Validators.pattern(/^[A-Za-zÀ-ú0-9\s\.,-]+, \d+$/)])]
    });
  }

  cadastrarEmpresa(){
    if (this.formulario.status){
        this.service.cadastrar(this.formulario.value).subscribe(() => {
        this.router.navigate(['/listarEmpresas']);
      });
    }
  }

  cancelar(){
    this.router.navigate(['/listarEmpresas']);
  }

  habilitarBotao() : string {
    return (this.formulario.valid) ? 'botao' : 'botao__desabilitado';
  }
}
