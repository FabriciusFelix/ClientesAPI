export interface ICliente{
  id: number,
  nome: string,
  sobrenome: string,
  codigoCpf: string,
  email: string,
  dataNascimento: Date,
  endereco: string,
  ativo: boolean,
  criadoEm: Date
}
