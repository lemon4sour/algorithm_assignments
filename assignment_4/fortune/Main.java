package fortune;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileWriter;
import java.io.IOException;
import java.security.spec.NamedParameterSpec;
import java.util.Random;
import java.util.Scanner;

public class Main {
	public static void main(String[] args) {
		
		String[] countries = loadFile("countries.txt");
		if (countries == null) return;
		
		Stack countryStack = new Stack(256);
		insertToStackSorted(countries, countryStack);
		
		
		
		String[] lines = loadFile("HighScoreTable.txt");
		if (lines == null) return;
		Stack names = new Stack(256);
		Stack scores = new Stack(256);
		insertHighScoreSorted(lines, names, scores);
		
		if (scores.peek()==null) {
			System.out.println("Incorrect file \"HighScoreTable.txt\"");
			return;
		}
		
		Stack letters = setLetters();
		
		Random random = new Random();
		
		//select random country
		int randomNumber = random.nextInt(countryStack.size());
		System.out.println("Randomly generated number: "+randomNumber);
		String selectedWord = getWordFromStack(countryStack, randomNumber);
		selectedWord = selectedWord.toLowerCase();
		
		Queue selectedWordQueue = new Queue(selectedWord.length());
		Queue uncoveredLetters = new Queue(selectedWord.length());
		
		int letterCount = 0;
		for (char c: selectedWord.toCharArray()) {
			selectedWordQueue.enqueue(c);
			if (c!=' ') {
				uncoveredLetters.enqueue('-');
				letterCount++;
			}
			else {
				uncoveredLetters.enqueue(' ');
			}
		}
		
		int step = 1;
		int score = 0;
		
		int uncovered = 0;
		
		//game start
		while (uncovered < letterCount) {
			//display uncovered letters
			System.out.print("\nWord  : ");
			displayQueue(uncoveredLetters);
			System.out.print("      Step : "+step+"   Score : "+score+"  ");
			displayStack(letters);
			
			String wheel = wheelSpin();
			
			if (wheel.equals("Bankrupt")) score=0;
			
			System.out.println("\nWheel : "+wheel);
			
			//select random letter
			char randomLetter = popCharFromStack(letters,random.nextInt(letters.size()));
			System.out.println("Guess : "+randomLetter);
			int found = 0;
			
			//count matches
			Queue buffer1 = new Queue(selectedWordQueue.size());
			Queue buffer2 = new Queue(uncoveredLetters.size());
			while (true) {
				char c1 = (char) selectedWordQueue.dequeue();
				char c2 = (char) uncoveredLetters.dequeue();
				if (c1==randomLetter) {
					buffer2.enqueue(randomLetter);
					found++;
					uncovered++;
				}
				else buffer2.enqueue(c2);
				
				buffer1.enqueue(c1);
				if (selectedWordQueue.isEmpty()) break;
			}
			while (true) {
				selectedWordQueue.enqueue(buffer1.dequeue());
				uncoveredLetters.enqueue(buffer2.dequeue());
				if (buffer1.isEmpty()) break;
			}
			
			if (wheel.equals("10")) score+=(10*found);
			else if (wheel.equals("50")) score+=(50*found);
			else if (wheel.equals("100")) score+=(100*found);
			else if (wheel.equals("250")) score+=(250*found);
			else if (wheel.equals("500")) score+=(500*found);
			else if (wheel.equals("1000")) score+=(1000*found);
			else if (wheel.equals("Double Money")) score*=(2^found);
			
			step++;
			
		}
		
		System.out.print("\nWord  : ");
		displayQueue(uncoveredLetters);
		System.out.print("      Step : "+step+"   Score : "+score+"  ");
		displayStack(letters);
		
		System.out.println("\n\n You won "+score+"$ !!!!\n");
		
		
		Stack nameBuffer = new Stack(names.size()+1);
		Stack scoreBuffer = new Stack(scores.size()+1);
		while (true) {
			if (score<=(int)scores.peek()) {
				scores.push(score);
				names.push("You");
				break;
			}
			else {
				nameBuffer.push(names.pop());
				scoreBuffer.push(scores.pop());
				if (scores.isEmpty()) {
					scores.push(score);
					names.push("You");
					break;
				}
			}
		}
		
		System.out.println("High Score Table");
		while (true) {
			if (scores.isEmpty()) break;
			nameBuffer.push(names.pop());
			scoreBuffer.push(scores.pop());
		}
		
		int i = 0;
		
		try {
			FileWriter writer = new FileWriter("HighScoreTable.txt");
			String text = "";
			while (true) {
				String writtenName = (String) nameBuffer.pop();
				int writtenScore = (int) scoreBuffer.pop();
				
				if (i<10) {	
					System.out.print(writtenName+"   ");
					System.out.println(writtenScore);
					i++;
				}
				text = text + writtenName + " " + writtenScore + "\n";
				if (scoreBuffer.isEmpty()) break;
			}
			writer.write(text);
			writer.close();
		} catch (IOException e) {}
		
		
	}
	
	static void displayQueue(Queue queue) {
		Queue buffer = new Queue(queue.size());
		while (true) {
			char character = (char) queue.dequeue();
			System.out.print(character+" ");
			buffer.enqueue(character);
			if (queue.isEmpty()) break;
		}
		while (true) {
			queue.enqueue(buffer.dequeue());
			if (buffer.isEmpty()) break;
		}
		
	}
	
	static void displayStack(Stack stack) {
		if (!stack.isEmpty()) {
			Stack buffer = new Stack(stack.size());
			while (true) {
				char character = (char) stack.pop();
				System.out.print(character);
				buffer.push(character);
				if (stack.isEmpty()) break;
			}
			while (true) {
				stack.push(buffer.pop());
				if (buffer.isEmpty()) break;
			}
		}
	}
	
	static String wheelSpin() {
		Random random = new Random();
		switch (random.nextInt(8)) {
		case 0:
			return "10";
		case 1:
			return "50";
		case 2:
			return "100";
		case 3:
			return "250";
		case 4:
			return "500";
		case 5:
			return "1000";
		case 6:
			return "Double Money";
		case 7:
			return "Bankrupt";
		}
		return "error";
	}
	
	static String[] loadFile(String filename) {
		try {
			File file = new File(filename);
			Scanner reader = new Scanner(file);
			String[] output = new String[256];
			int index = 0;
			if (!reader.hasNextLine()) {
				System.out.println("File empty.");
				return null;
			}
			while (reader.hasNextLine()) {
				
				
				try {
					String line = reader.nextLine();
					output[index] = line;
					index++;
				}
				//out of range handler
				catch (IndexOutOfBoundsException e) {
					System.out.println("File too large.");
					return output;
				}
			}
			return output;
		}
		//file not found handler
		catch (FileNotFoundException e) {
			System.out.println("File not found.");
			return null;
		}
	}
	
	static Stack setLetters() {
		
		Stack output = new Stack(26);
		char[] alphabet = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
		for (char c : alphabet) {
			output.push(c);
		}
		return output;
	}
	
	static String getWordFromStack(Stack stack,int index) {
		Stack buffer = new Stack(stack.size());
		for (int i = 0; i < index; i++) {
			buffer.push(stack.pop());
		}
		String output = (String) stack.peek();
		while (true) {
			if (buffer.isEmpty()) break;
			stack.push(buffer.pop());
		}
		return output;
	}
	
	static char popCharFromStack(Stack stack,int index) {
		Stack buffer = new Stack(stack.size());
		for (int i = 0; i < index; i++) {
			buffer.push(stack.pop());
		}
		char output = (char) stack.pop();
		while (true) {
			if (buffer.isEmpty()) break;
			stack.push(buffer.pop());
		}
		return output;
	}
	
	static void insertToStackSorted(String[] words, Stack stack) {
		Stack buffer = new Stack(words.length);
		
		//loop through each word
		for (String word : words) {
			if (word==null) break;
			//start
			if (stack.peek() == null) {
				stack.push(word);
			}
			
			else {
				int comparison = word.compareToIgnoreCase((String) stack.peek());
				if (comparison != 0) {
					if (comparison < 0) stack.push(word);
					else {
						
						while (true) {
							
							//move one to buffer
							buffer.push(stack.pop());
							
							//drop to bottom
							if (stack.isEmpty()) {
								stack.push(word);
								break;
							}
							
							//land in middle
							if (word.compareToIgnoreCase((String) stack.peek()) < 0) {
								stack.push(word);
								break;
							}
						}
						
						//clear buffer
						while (true) {
							if (buffer.isEmpty()) break;
							stack.push(buffer.pop());
						}
					}
				}
			}
		}
		
		
	}
	
	
	static void insertHighScoreSorted(String[] lines, Stack names, Stack scores) {
		Stack nameBuffer = new Stack(lines.length);
		Stack scoreBuffer = new Stack(lines.length);
		
		//loop through each word
		for (String line : lines) {
			if (line==null) break;
			
			String[] splitLine = line.split(" ");
			
			if (splitLine.length != 2) continue;
			String name = splitLine[0];
			int score;
			try {
				score = Integer.parseInt(splitLine[1]);
			}
			catch (NumberFormatException e) {
				continue;
			}
			
			//start
			if (scores.peek() == null) {
				scores.push(score);
				names.push(name);
			}
			
			else {
				if ((int) scores.peek() >= score) {
					scores.push(score);
					names.push(name);
				}
				else {
					
					while (true) {
						
						//move one to buffer
						scoreBuffer.push(scores.pop());
						nameBuffer.push(names.pop());
						
						//drop to bottom
						if (scores.isEmpty()) {
							scores.push(score);
							names.push(name);
							break;
						}
						
						//land in middle
						if ((int) scores.peek() > score) {
							scores.push(score);
							names.push(name);
							break;
						}
					}
					
					//clear buffer
					while (true) {
						if (scoreBuffer.isEmpty()) break;
						names.push(nameBuffer.pop());
						scores.push(scoreBuffer.pop());
					}
				}
			}
		}
		
		
	}
}
