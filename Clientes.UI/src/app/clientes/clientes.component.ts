import { Component, OnInit } from '@angular/core';
import { Form, FormControl, FormGroup } from '@angular/forms';
import { ClienteService } from './cliente.service';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { ICliente } from './ICliente';
@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit{

  formulario:FormGroup;

  tituloFormulario:string = '';
  teste:string = '';
  public clientes:any = [

  ];
  constructor(private http:HttpClient) {
    this.formulario = new FormGroup({})

  }
  ngOnInit(): void {

    this.formulario = new FormGroup({
      id: new FormControl(0),
      nome:new FormControl(''),
      sobrenome:new FormControl(''),
      codigoCpf:new FormControl(''),
      email:new FormControl(''),
      dataNascimento:new FormControl(''),
      endereco:new FormControl(''),
      ativo:new FormControl(true),
      criadoEm: new FormControl(new Date())
    })
    this.tituloFormulario = 'Novo Cliente ';
  }


  public getClientes(): void{

     this.http.get('http://localhost:5235/api/Clientes').subscribe(
      response => this.clientes = response,
      error => console.log(error)
    );
  }

  public postClientes(formData:FormGroup): void{
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type':'application/json'})
    }
    console.log(JSON.stringify(formData.value))
    this.http.post<ICliente>('http://localhost:5235/api/Clientes', JSON.stringify(formData.value),httpOptions).subscribe(
      response => { console.log('Post Executado. Resposta: ',JSON.stringify(response))},
      error => console.log(error)
    );

    console.log(JSON.stringify(this.teste));
  }
}
