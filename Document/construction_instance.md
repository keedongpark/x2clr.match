# 인스턴스 실행 구조와 인스턴스 관리 


## 쓰레드 활용 

### Session 서버의 경우 

 UserCase를 두고 여러 플로우에 넣어서 처리하게 한다면 
 Account로 바인딩해서 요청을 받을 수 있다. 
 보내는 것은 Send로 Binding 하면 된다. 

 LoginCase에서 UserCase를 생성하고 적절한 Flow에 넣어준다. 

 Event에 Context를 넣으면 Post / Bind를 보다 유연하게 처리할 수 있다. 

### InstanceCoordinator 

 Join 요청 시 InstanceId가 0인 경우에 대해 바인딩 
 Flow를 찾아서 해당 Flow 안에 생성. 

 소멸은 어떻게 하는가? 

#### Case 소멸 

 Builtin Event 필요. 이를 통해 이벤트들 다 처리되고 처리되게 함. 
 Teardown에서 application 수준의 처리 진행. 

 Leave 시 member가 없으면 소멸 하는 것으로 전체 흐름 테스트. 

 


 




