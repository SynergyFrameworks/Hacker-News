import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { throwError, combineLatest, BehaviorSubject } from 'rxjs';

import { HackerNews } from './HackerNews';
import { tap, catchError, shareReplay, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HackerNewsService {
    private hackerNewsServiceUrl = 'http://localhost:4000/api/v1/news?apiRoute=2';
  //private hackerNewsServiceUrl = 'https://hackerserviceapi20200323192500.azurewebsites.net/api/v1/news?apiRoute=2';

  hackerNewsCached$ = this.http.get<HackerNews[]>(this.hackerNewsServiceUrl)
    .pipe(
      tap(data => console.log('news', JSON.stringify(data))),
      shareReplay(1),
      catchError(this.handleError)
    );

    news$  = this.http.get<HackerNews[]>(this.hackerNewsServiceUrl)
    .pipe(
      tap(data => console.log('HackerNews: ', JSON.stringify(data))),
      catchError(this.handleError)
    );

    private newsSelectedSubject = new BehaviorSubject<number>(0);
    newsSelectedAction$ = this.newsSelectedSubject.asObservable();

  selectedNews$ = combineLatest([
    this.hackerNewsCached$,
    this.newsSelectedAction$
  ])
    .pipe(
      map(([news, selectedNewsId]) =>
        news.filter(newsx =>
          selectedNewsId ? newsx.id === selectedNewsId : true
        )),
        tap(news => console.log('selectedNews', news)),
        shareReplay(1)
    );

    // newsWithSearch$ = combineLatest([
    // this.news$,
    //  this.hackerNews$
    // ]).pipe(
    //   map(([news, search]) =>
    //     news.map(news => ({
    //       ...news,
    //       score: news.score * 1.25,
    //       search: search.find(c => news.id === c.id).title,
    //       searchKey: [news.title]
    //     }) as HackerNews)
    //   ),
    //   shareReplay(1)
    // );



      selectedNewsChanged(selectedId: number): void {
        this.newsSelectedSubject.next(selectedId);
      }

  constructor(private http: HttpClient) { }

  private handleError(err: any) {
    // in a real world app, we may send the server to some remote logging infrastructure
    // instead of just logging it to the console
    let errorMessage: string;
    if (err.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      errorMessage = `An error occurred: ${err.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      errorMessage = `Backend returned code ${err.status}: ${err.body.error}`;
    }
    console.error(err);
    return throwError(errorMessage);
  }
}

