import { Component, OnInit } from '@angular/core';
import { EventoService } from '../_services/evento.service';
import { Evento } from '../_models/Evento';

@Component({
    selector: 'app-eventos',
    templateUrl: './eventos.component.html',
    styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

    eventosFiltrados: Evento[];
    eventos: Evento[];
    imagemLargura = 50;
    imagemMargem = 2;
    mostrarImagem = false;

    _filtroLista: string;
    get filtroLista(): string {
        return this._filtroLista;
    }
    set filtroLista(value: string) {
        this._filtroLista = value;
        this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
    }

    constructor(
        private eventoService: EventoService
    ) { }

    ngOnInit() {
        this.getEventos();
    }

    alternarImagem() {
        this.mostrarImagem = !this.mostrarImagem;
    }

    getEventos() {
        this.eventoService.getAllEventos()
            .subscribe(
                (_eventos: Evento[]) => {
                    this.eventos = _eventos;
                    this.eventosFiltrados = this.eventos;
                },
                error => {
                    console.log(error);
                }
            );
    }

    filtrarEventos(filtrarPor: string): Evento[] {
        filtrarPor = filtrarPor.toLocaleLowerCase();
        return this.eventos.filter(
            evento => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1
        );
    }

}
