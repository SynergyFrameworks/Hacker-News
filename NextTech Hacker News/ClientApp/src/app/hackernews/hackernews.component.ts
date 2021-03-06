import { Component, OnInit } from '@angular/core';
import { HackerNewsService } from '../service/hackernews.service';
import { Subject, BehaviorSubject, EMPTY } from 'rxjs';
import { map, catchError } from 'rxjs/operators';


@Component({
  selector: 'app-hacker-news',
  templateUrl: './hackernews.component.html',
  styleUrls: ['./hackernews.component.scss']
})
export class HackerNewsComponent implements OnInit {

  pageTitle = 'Hacker News';
  private errorMessageSubject = new Subject<string>();
  errorMessage$ = this.errorMessageSubject.asObservable();

  private newsSelectedSubject = new BehaviorSubject<number>(0);
  newsSelectedAction$ = this.newsSelectedSubject.asObservable();
  counter: number;



  news$ = this.hackerNewsService.hackerNewsCached$
  .pipe(
    catchError(err => {
      this.errorMessageSubject.next(err);
      return EMPTY;
    })
  );



  constructor( private hackerNewsService: HackerNewsService) { }

  ngOnInit() {
  }

  onSelected(newsId: string): void {
    this.newsSelectedSubject.next(+newsId);
  }

}
