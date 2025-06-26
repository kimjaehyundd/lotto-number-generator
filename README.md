# 🎰 로또 번호 생성기

![.NET](https://img.shields.io/badge/.NET-6.0-purple)
![C#](https://img.shields.io/badge/C%23-11.0-blue)
![License](https://img.shields.io/badge/license-MIT-green)
![Build](https://img.shields.io/badge/build-passing-brightgreen)

**엔터프라이즈급 C# 콘솔 로또 번호 생성기** - 1부터 45까지 숫자 중에서 중복 없이 6개의 번호를 생성하는 고급 프로그램입니다.

## ✨ 주요 기능

### 🎲 **번호 생성 기능**
- **단일 세트 생성**: 로또 번호 1세트 즉시 생성
- **다중 세트 생성**: 최대 10세트까지 한 번에 생성
- **중복 없는 생성**: HashSet을 사용한 완벽한 중복 제거
- **자동 정렬**: 생성된 번호 자동 오름차순 정렬

### 📊 **데이터 관리 기능**
- **이력 관리**: JSON 파일로 생성 이력 자동 저장
- **통계 분석**: 가장 많이 나온 번호 TOP 10 분석
- **시간 기록**: 각 번호 세트의 생성 시간 기록
- **데이터 영속성**: 프로그램 재시작 후에도 이력 유지

### 🎨 **사용자 경험**
- **직관적 메뉴**: 숫자 기반의 간편한 메뉴 시스템
- **행운 메시지**: 랜덤 행운 메시지로 재미 요소 추가
- **시각적 효과**: 이모지와 구분선으로 가독성 향상
- **오류 처리**: 잘못된 입력에 대한 친절한 안내

## 🚀 설치 및 실행

### 📋 **시스템 요구사항**
- **.NET 6.0** 이상
- **Windows 10/11** 또는 **macOS/Linux**
- **Visual Studio 2022** 또는 **VS Code** (권장)

### 💾 **다운로드 및 설치**

#### **방법 1: Git Clone**
```bash
git clone https://github.com/kimjaehyundd/lotto-number-generator.git
cd lotto-number-generator
```

#### **방법 2: ZIP 다운로드**
1. [릴리즈 페이지](https://github.com/kimjaehyundd/lotto-number-generator/releases)에서 최신 버전 다운로드
2. 압축 해제 후 폴더로 이동

### ⚡ **실행 방법**

#### **Visual Studio에서 실행**
1. `LottoNumberGenerator.csproj` 파일 더블클릭
2. `F5` 키 또는 "시작" 버튼 클릭

#### **명령줄에서 실행**
```bash
# 개발 모드로 실행
dotnet run

# 릴리즈 빌드 후 실행
dotnet build -c Release
dotnet run -c Release
```

## 🎮 사용법

### **메인 메뉴**
```
🎰 로또 번호 생성기 v1.0.0 🎰
==================================================
📅 빌드 날짜: 2025-06-26
👤 개발자: 김재현

📋 메뉴를 선택해주세요:
1. 로또 번호 1세트 생성
2. 로또 번호 여러 세트 생성
3. 생성 이력 보기
4. 번호 통계 보기
5. 종료

선택: 
```

### **1. 단일 세트 생성**
```
🎲 로또 번호를 생성중입니다...

🎉 생성된 로또 번호:
   3 - 15 - 22 - 31 - 38 - 44

🍀 오늘은 당신의 행운의 날입니다!
```

### **2. 다중 세트 생성**
```
몇 세트를 생성하시겠습니까? (1-10): 3

🎲 로또 번호 3세트를 생성중입니다...

🎉 생성된 로또 번호들:
----------------------------------------
세트  1: 7 - 14 - 23 - 29 - 35 - 42
세트  2: 2 - 11 - 18 - 26 - 33 - 45
세트  3: 5 - 16 - 21 - 28 - 37 - 41
----------------------------------------
✨ 총 3세트 생성 완료! 행운을 빕니다! ✨
```

## 🛠 기술적 특징

### **🏗 아키텍처**
- **객체지향 설계**: 책임 분리를 통한 깔끔한 코드 구조
- **SOLID 원칙**: 단일 책임, 의존성 역전 등 설계 원칙 적용
- **예외 처리**: 파일 I/O 및 사용자 입력 오류 처리
- **메모리 효율성**: HashSet을 사용한 효율적인 중복 제거

### **📁 프로젝트 구조**
```
LottoNumberGenerator/
├── Program.cs                    # 메인 프로그램
├── LottoNumberGenerator.csproj   # 프로젝트 설정
├── README.md                     # 프로젝트 문서
├── .gitignore                    # Git 제외 파일
└── lotto_history.json           # 생성 이력 (자동 생성)
```

### **🔧 핵심 클래스**

#### **Program 클래스**
- 메인 실행 로직 및 사용자 인터페이스
- 이력 관리 및 통계 표시
- JSON 직렬화/역직렬화

#### **LottoGenerator 클래스**
- 로또 번호 생성 핵심 로직
- 단일/다중 세트 생성
- 행운 메시지 관리

#### **LottoResult 클래스**
- 생성 결과 데이터 모델
- 번호 리스트 및 생성 시간 저장

## 🎯 학습 포인트

이 프로젝트를 통해 다음을 배울 수 있습니다:

### **🟢 C# 기초 개념**
- ✅ 클래스와 객체
- ✅ 생성자와 메서드
- ✅ 프로퍼티와 필드
- ✅ 네임스페이스 활용

### **🟡 고급 C# 기능**
- ✅ LINQ (OrderBy, TakeLast)
- ✅ Generic Collections (List, HashSet, Dictionary)
- ✅ 람다 표현식
- ✅ 문자열 보간법

### **🟠 데이터 처리**
- ✅ JSON 직렬화/역직렬화
- ✅ 파일 입출력 (File I/O)
- ✅ 예외 처리 (try-catch)
- ✅ 날짜/시간 처리

### **🔵 알고리즘 및 로직**
- ✅ 랜덤 숫자 생성
- ✅ 중복 제거 알고리즘
- ✅ 정렬 알고리즘
- ✅ 빈도 분석

## 📊 로또 관련 통계

### **🎲 확률 정보**
- **1등 당첨 확률**: 1/8,145,060 (약 0.000012%)
- **전체 가능한 조합**: 8,145,060가지
- **같은 번호가 나올 확률**: 거의 0에 가까움

## 👨‍💻 개발자 정보

**김재현 (Kim Jaehyun)**
- GitHub: [@kimjaehyundd](https://github.com/kimjaehyundd)
- 프로젝트 GitHub: [lotto-number-generator](https://github.com/kimjaehyundd/lotto-number-generator)

## 📞 지원 및 문의

- **버그 리포트**: [Issues](https://github.com/kimjaehyundd/lotto-number-generator/issues)
- **기능 요청**: [Feature Request](https://github.com/kimjaehyundd/lotto-number-generator/issues/new)

---

**🍀 행운을 빕니다! 대박나세요! 🍀**

> ⚠️ **면책조항**: 이 프로그램은 교육 및 오락 목적으로 제작되었습니다. 실제 로또 당첨을 보장하지 않으며, 도박 중독 예방을 위해 적절한 선에서 즐겨주시기 바랍니다.