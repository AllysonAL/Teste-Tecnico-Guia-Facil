import { Component, Input } from '@angular/core';
import { IEmpresa } from './../../Models/empresa.model';

@Component({
  selector: 'app-empresa',
  standalone: false,
  templateUrl: './empresa.html',
  styleUrl: './empresa.css',
})
export class Empresa {
constructor(){}

  @Input() empresa!: IEmpresa;
}
