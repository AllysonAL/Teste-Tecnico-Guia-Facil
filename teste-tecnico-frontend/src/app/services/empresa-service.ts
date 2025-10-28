import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { IEmpresa } from './../Models/empresa.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmpresaService {
  private readonly API = 'http://localhost:5200/empresas';

  constructor(private http : HttpClient) { }

  listar(filtro : string) : Observable<IEmpresa[]> {
      if (filtro.trim().length > 2){
        const url = `${this.API}/nome/${filtro}`;
        return this.http.get<IEmpresa[]>(url)
      }

      return this.http.get<IEmpresa[]>(this.API);
  }

  cadastrar(empresa : IEmpresa) : Observable<IEmpresa> {
    return this.http.post<IEmpresa>(this.API, empresa);
  }

  editar(empresa : IEmpresa) : Observable<IEmpresa> {
    return this.http.put<IEmpresa>(this.API, empresa);
  }

  buscarPorId(id : string) : Observable<IEmpresa>{
    const url = `${this.API}/${id}`;
    return this.http.get<IEmpresa>(url);
  }

  excluir(id : string) : Observable<IEmpresa> {
    const url = `${this.API}/${id}`;
    return this.http.delete<IEmpresa>(url);
  }
}
