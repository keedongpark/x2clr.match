# Couchbase


## 기초 

 - CouchbaseNetClient 설치  
   - NuGet으로 검색 및 설치 

 - Couchbase Community Server 설치 
   - [관리](http://localhost:8091/index.html)
   - Administrator / nw4any 

 - NewtonSoft.Json에 의존 

## 처리기 

 - MultiThreadFlow에 이벤트로 전송 
 - UserDbCase와 같은 하나의 케이스에서 처리 
 - EventDbLoadUserReq / Resp 
   - Account와 Context에 바인딩해서 처리 
 - EventDbUpdateUserReq / Resp
   - 

## Example 

 - [Examples](https://github.com/couchbaselabs/couchbase-net-examples/tree/master/Src)
   - dynamic을 사용하지 않는 예시들. dynamic은 느리고 Rosyln을 추가 설치해야 함. 
   - 클래스를 문서화 해서 사용




