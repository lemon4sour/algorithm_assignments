package yahtzee;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Random;
import java.util.Scanner;

public class Main {

	public static void main(String[] args) {
		
		SingleLinkedList p1 = new SingleLinkedList();
		SingleLinkedList p2 = new SingleLinkedList();
		
		int score1 = 0;
		int score2 = 0;
		
		Random random = new Random();
		
		for (int turn = 1; turn <= 10; turn++) {
			System.out.print("Turn "+turn+":");
			
			for (int i = 0; i < 3; i++) {
				p1.add(random.nextInt(6)+1);
			}
			for (int i = 0; i < 3; i++) {
				p2.add(random.nextInt(6)+1);
			}
			
			System.out.print("\nPlayer1: ");
			p1.view();
			System.out.println("     score = "+ score1);
			System.out.print("Player2: ");
			p2.view();
			System.out.println("     score = "+ score2 + "\n");
			
			boolean displayAgain = false;
			
			int[] count = new int[6];
			
			//player 1
			for (int i = 0; i < 6; i++) {
				count[i] = p1.count(i+1);
			}
			
			int largeStraightCount = -1;
			for (int counter : count) {
				if ((largeStraightCount == -1) || (largeStraightCount > counter)) {
					largeStraightCount = counter;
				}
			}
			
			for (int i = 0; i < largeStraightCount; i++) {
				for (int j = 1; j <= 6; j++) {
					p1.remove(j);
				}
				displayAgain = true;
				score1+=30;
			}
			
			for (int i = 0; i < 6; i++) {
				count[i] = p1.count(i+1);
			}
			
			//yahtzee
			for (int i = 0; i < 6; i++) {
				if (count[i] > 3) {
					for (int j = 0; j < 4; j++) {
						p1.remove(i+1);
					}
					score1+=10;
					displayAgain = true;
				}
			}
			
			//player 2
			for (int i = 0; i < 6; i++) {
				count[i] = p2.count(i+1);
			}
			
			largeStraightCount = -1;
			for (int counter : count) {
				if ((largeStraightCount == -1) || (largeStraightCount > counter)) {
					largeStraightCount = counter;
				}
			}
			
			for (int i = 0; i < largeStraightCount; i++) {
				for (int j = 1; j <= 6; j++) {
					p2.remove(j);
				}
				displayAgain = true;
				score2+=30;
			}
			
			for (int i = 0; i < 6; i++) {
				count[i] = p2.count(i+1);
			}
			
			//yahtzee
			for (int i = 0; i < 6; i++) {
				if (count[i] > 3) {
					for (int j = 0; j < 4; j++) {
						p2.remove(i+1);
					}
					score2+=10;
					displayAgain = true;
				}
			}
			
			if (displayAgain) {
				System.out.print("\nPlayer1: ");
				p1.view();
				System.out.println("     score = "+ score1);
				System.out.print("Player2: ");
				p2.view();
				System.out.println("     score = "+ score2 + "\n");
			}
		}
		
		System.out.println("Game is over.\n");
		
		if (score1 > score2) {
			System.out.println("The winner is player 1.");
		}
		else if (score1 < score2) {
			System.out.println("The winner is player 2.");
		}
		else {
			System.out.println("Tie.");
		}
		
		System.out.println("\nHigh Score Table");
		
		SingleLinkedList highScoreTable = new SingleLinkedList();
		
		boolean toggle = true;
		String[] file = loadFile("HighScoreTable.txt");
		if (file != null) {
			String name = null;
			for (String str : file) {
				if (str == null) break;
				
				int score;
				if (toggle) {
					name = str;
				}
				else {
					score = Integer.parseInt(str);
					highScoreTable.insertSorted(name, score);
				}
				toggle = !toggle;
			}
			
			highScoreTable.removeScore("Player1");
			highScoreTable.removeScore("Player2");
			
			highScoreTable.insertSorted("Player1", score1);
			highScoreTable.insertSorted("Player2", score2);
			highScoreTable.saveToFile("HighScoreTable.txt");
		}
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
	
}
