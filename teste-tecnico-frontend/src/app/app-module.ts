import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Cabecalho } from './componentes/cabecalho/cabecalho';
import { Rodape } from './componentes/rodape/rodape';
import { ListarEmpresas } from './componentes/listar-empresas/listar-empresas';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CadastrarEmpresa } from './componentes/cadastrar-empresa/cadastrar-empresa';
import { EditarEmpresa } from './componentes/editar-empresa/editar-empresa';
import { Empresa } from './componentes/empresa/empresa';
import { ExcluirEmpresa } from './componentes/excluir-empresa/excluir-empresa';

@NgModule({
  declarations: [
    App,
    Cabecalho,
    Rodape,
    ListarEmpresas,
    CadastrarEmpresa,
    EditarEmpresa,
    Empresa,
    ExcluirEmpresa
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideHttpClient()
  ],
  bootstrap: [App]
})
export class AppModule { }
